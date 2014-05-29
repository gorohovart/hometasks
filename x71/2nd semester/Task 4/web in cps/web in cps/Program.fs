// Gorokhov Artem (c) 2014
// 2nd semester HW 4
// Web in continuation passing style
// Takes list of urls 
// Returns list of image links of urls that contains more than 5 images
module imgParse

open WebR
open System

let urls =
    [
     "http://images.yandex.ru";
     "http://google.com";
    ]

let flag = ref false

let rec wait() =
    if not !flag then System.Threading.Thread.Sleep(200)
                      wait()

let imgNum (page:string) = 
    let rec num (pos:int) =
        let x = page.IndexOf ("<img", pos)
        if x = -1 then 0
                  else 1 + num (x + 4)
    num 0

let getImages (page:string) =
    let rec get (pos:int) =
        let x = page.IndexOf ("<img", pos)
        if x = -1 then []
                  else let y = page.IndexOf ("src=", x)
                       let z = page.IndexOf ("\"", y + 5)
                       [page.Substring (y + 5, z - y - 5)] :: get z
    Seq.distinct (get 0) |> Seq.toList

let rec parse urls g =
    match urls with
    | [] -> flag := true
            g []
    | hd :: tl -> getUrl hd (fun x -> parse tl (fun y -> g ((if imgNum x < 6 then [] else getImages x) @ y)))
                    
parse urls (printfn "%A")
wait()