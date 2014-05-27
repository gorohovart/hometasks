module Intersect

let eps = 0.000000001

let areEqual x y = abs(x - y) < eps

let greaterOrEqual x y = (x > y) || (areEqual x y)
let lessOrEqual x y = (x < y) || (areEqual x y)

type Geom = 
    | NoPoint                  // пустое множество
    | Point of float * float   // точка
    | Line  of float * float   // уравнение прямой y = a*x+b
    | VerticalLine of float    // вертикальная прямая проходящая через x
    | LineSegment of (float * float) * (float * float) // отрезок
  //| Intersect of Geom * Geom // пересечение двух множеств

let verticalLineIntersectLineSegment x x1 y1 x2 y2 =
    if areEqual x1 x2 then 
        if areEqual x1 x then LineSegment((x1, y1),(x2, y2))
        else NoPoint
    else if (greaterOrEqual x (min x1 x2)) && (lessOrEqual x (max x1 x2)) then
        let a = (y1 - y2)/(x1 - x2)
        let b = y1 - x1 * a
        Point(x, a * x + b)
    else
        NoPoint

let rec intersectOfLineSegments x11 y11 x12 y12 x21 y21 x22 y22 = 
    let a = (y11 - y12)/(x11 - x12)
    let b = y11 - x11 * a

    if (min x11 x12) < (min x21 x22) then
         if (max x11 x12) < (min x21 x22) then
            NoPoint
         elif areEqual(max x11 x12) (min x21 x22) then
            Point(max x11 x12, a * (max x11 x12) + b)
         elif (max x11 x12) > (max x21 x22) then 
            LineSegment((x21, y21),(x22, y22))
         else LineSegment((min x21 x22, a * (min x21 x22) + b),(max x11 x12, a * (max x11 x12) + b))
    elif areEqual (min x11 x12) (min x21 x22) then
         if greaterOrEqual (max x11 x12) (max x21 x22) then
            LineSegment((x11, y11),(x12, y12))
         else LineSegment((min x11 x12, a * (min x11 x12) + b),(max x21 x22, a * (max x21 x22) + b))
    else intersectOfLineSegments x21 y21 x22 y22 x11 y11 x12 y12

let isPointOnSegment x y x1 y1 x2 y2 =
    let a = (y1 - y2)/(x1 - x2)
    let b = y1 - x1 * a
    
    (areEqual (a * x + b) y) && (lessOrEqual x (max x1 x2)) && (greaterOrEqual x (min x1 x2))

let verticalSegmentIntersectSegment x11 y11 y12 x21 y21 x22 y22 =
    match verticalLineIntersectLineSegment x11 x21 y21 x22 y22 with
    | NoPoint -> NoPoint
    | Point (x, y) -> if (y < max y11 y12) && (y > min y11 y22) then
                          Point(x, y)
                      else NoPoint

let pointIntersectPoint x1 y1 x2 y2 =
    if (areEqual x1 x2 && areEqual y1 y2) then
        Point (x1, y1)
    else
        NoPoint

let lineIntersectLine a1 b1 a2 b2 =
    if areEqual a1 a2 then
        if areEqual b1 b2 then
            Line (a1, b1)
        else
            NoPoint
    else
        Point (((b1 - b2)/(a2 - a1)), ((a1 * b2 - a2 * b1)/(a1 - a2)))

let verticalLineIntersectVerticalLine x1 x2 =
    if areEqual x1 x2 then
        VerticalLine x1
    else
        NoPoint

let lineSegmentIntersectLineSegment x11 y11 x12 y12 x21 y21 x22 y22 =
    if areEqual x11 x12 then
        if areEqual x21 x22 then
            if areEqual x11 x21 then
                let y1 = max (min y11 y12) (min y21 y22)
                let y2 = min (max y11 y12) (max y21 y22)

                if (y1 > y2) then
                    NoPoint
                elif areEqual y1 y2 then
                    Point (x11, y1)
                else
                    LineSegment ((x11, y1), (x11, y2))
            else
                NoPoint
        else
            verticalSegmentIntersectSegment x11 y11 y12 x21 y21 x22 y22
    elif areEqual x21 x22 then
        verticalSegmentIntersectSegment x21 y21 y22 x11 y11 x12 y12 
    else            
    let a1 = (y11 - y12)/(x11 - x12)
    let b1 = y11 - x11 * a1
    let a2 = (y21 - y22)/(x21 - x22)
    let b2 = y21 - x21 * a2

    match lineIntersectLine a1 b1 a2 b2 with
    | NoPoint -> NoPoint
    | Line (a, b) -> intersectOfLineSegments x11 y11 x12 y12 x21 y21 x22 y22          
    | Point (x, y) -> if isPointOnSegment x y x11 y11 x12 y12 && isPointOnSegment x y x21 y21 x22 y22 then 
                          Point (x, y)
                      else
                          NoPoint
//point
let pointIntersectLine x y a b =
    if areEqual (a * x + b) y then Point (x, y)
                   else NoPoint

let pointIntersectVerticalLine x y x1 =
    if areEqual x x1 then Point (x, y)
              else NoPoint

let pointIntersectLineSegment x y x1 y1 x2 y2 =
    if areEqual x1 x2 then
        if (areEqual x x1) && (greaterOrEqual y (min y1 y2)) && (lessOrEqual y (max y1 y2)) then 
            Point (x, y)
        else NoPoint
    else
        let a = (y1 - y2)/(x1 - x2)
        let b = y1 - x1 * a

        match pointIntersectLine x y a b with
        | Point (_,_) -> if (greaterOrEqual x (min x1 x2)) && (lessOrEqual x (max x1 x2)) then
                            Point (x, y)
                         else
                            NoPoint  
        | NoPoint -> NoPoint
//line
let lineIntersectPoint a b x y = pointIntersectLine x y a b

let lineIntersectVerticalLine a b x =
    Point(x, a * x + b)

let lineIntersectLineSegment a b x1 y1 x2 y2 =
    if areEqual x1 x2 then
        let y = a * x1 + b
        if (greaterOrEqual y (min y1 y2)) && (lessOrEqual y (max y1 y2)) then 
            Point (x1, y)
        else
            NoPoint
    else
        let a1 = (y1 - y2)/(x1 - x2)
        let b1 = y1 - x1 * a1
        
        match lineIntersectLine a b a1 b1 with
        | NoPoint -> NoPoint
        | Line (a, b) -> LineSegment ((x1, y1),(x2, y2))
        | Point (x, y) -> if isPointOnSegment x y x1 y1 x2 y2 then 
                              Point (x, y)
                          else
                              NoPoint
//vert line
let verticalLineIntersectPoint x x1 y1 = pointIntersectVerticalLine x1 y1 x

let verticalLineIntersectLine x a b = lineIntersectVerticalLine a b x

//line segment
let lineSegmentIntersectPoint x1 y1 x2 y2 x y = pointIntersectLineSegment x y x1 y1 x2 y2

let lineSegmentIntersectLine x1 y1 x2 y2 a b = lineIntersectLineSegment a b x1 y1 x2 y2

let lineSegmentIntersectVerticalLine x1 y1 x2 y2 x = verticalLineIntersectLineSegment x x1 y1 x2 y2

//somethingIntersect
let pointIntersect x y g =
    match g with
    | NoPoint -> NoPoint
    | Point (x1, y1) -> pointIntersectPoint x y x1 y1
    | Line (a, b) -> pointIntersectLine x y a b
    | VerticalLine x1 -> pointIntersectVerticalLine x y x1
    | LineSegment ((x1, y1), (x2, y2)) -> pointIntersectLineSegment x y x1 y1 x2 y2

let lineIntersect a b g =
    match g with
    | NoPoint -> NoPoint
    | Point (x, y) -> lineIntersectPoint a b x y
    | Line (a1, b1) -> lineIntersectLine a b a1 b1
    | VerticalLine x -> lineIntersectVerticalLine a b x
    | LineSegment ((x1, y1), (x2, y2)) -> lineIntersectLineSegment a b x1 y1 x2 y2

let verticalLineIntersect x g =
    match g with
    | NoPoint -> NoPoint
    | Point (x1, y1) -> verticalLineIntersectPoint x x1 y1
    | Line (a, b) -> verticalLineIntersectLine x a b
    | VerticalLine x1 -> verticalLineIntersectVerticalLine x x1
    | LineSegment ((x1, y1), (x2, y2)) -> verticalLineIntersectLineSegment x x1 y1 x2 y2

let lineSegmentIntersect x1 y1 x2 y2 g =
    match g with
    | NoPoint -> NoPoint
    | Point (x, y) -> lineSegmentIntersectPoint x1 y1 x2 y2 x y
    | Line (a, b) -> lineSegmentIntersectLine x1 y1 x2 y2 a b
    | VerticalLine x -> lineSegmentIntersectVerticalLine x1 y1 x2 y2 x
    | LineSegment ((x21, y21), (x22, y22)) -> lineSegmentIntersectLineSegment x1 y1 x2 y2 x21 y21 x22 y22

//main
let intersect g1 g2 = 
    match g1 with
    | NoPoint -> NoPoint
    | Point (x, y) -> pointIntersect x y g2
    | Line (a, b) -> lineIntersect a b g2
    | VerticalLine x -> verticalLineIntersect x g2
    | LineSegment ((x1, y1), (x2, y2)) -> lineSegmentIntersect x1 y1 x2 y2 g2