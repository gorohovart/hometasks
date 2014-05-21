// Gorokhov Artem (c) 2014
// 2nd semester HW 6
// Dictionary

module Map = 
    open System.Collections.Generic
    open System.Collections
/// <summary>Immutable maps. Keys are ordered by F# generic comparison.</summary>
///
/// <remarks>Map interface based on Microsoft.FSharp.Collections.Map
/// (See: https://github.com/fsharp/fsharp/blob/master/src/fsharp/FSharp.Core/map.fsi)</remarks>

    type Tree<'Key, 'Value when 'Key: comparison> = 
        | Empty
        | Node of left: Tree<'Key, 'Value> * right: Tree<'Key, 'Value> * key: 'Key * value: 'Value * lHeight: int * rHeight: int

    let private height tree =
        match tree with
        | Empty -> 0
        | Node(_,_,_,_,lh,rh) -> max lh rh + 1

    let private balance tree = 
        match tree with
        | Empty -> Empty
        | Node(alt, art, ax, ay, alh, arh) -> 
            if arh - alh = 2 then
                match art with
                | Empty -> failwith "Incorrect heights"
                | Node(blt, brt, bx, by, blh, brh) -> 
                    if blh <= brh then // small left rotate
                        let a = Node(alt, blt, ax, ay, alh, blh)
                        Node(a, brt, bx, by, height a, brh)
                    else               // huge left rotate
                        match blt with 
                        | Empty -> failwith "Incorrect heights"
                        | Node(clt, crt, cx, cy, clh, crh) ->
                            let a = Node(alt, clt, ax, ay, alh, clh)
                            let b = Node(crt, brt, bx, by, crh, brh)
                            Node(a, b, cx, cy, height a, height b)
            elif alh - arh = 2 then
                match alt with
                | Empty -> failwith "Incorrect heights"
                | Node(blt, brt, bx, by, blh, brh) -> 
                    if brh <= blh then // small right rotate
                        let a = Node(brt, art, ax, ay, brh, arh)
                        Node(blt, a, bx, by, blh, height a)
                    else               // huge right rotate
                        match brt with 
                        | Empty -> failwith "Incorrect heights"
                        | Node(clt, crt, cx, cy, clh, crh) ->
                            let a = Node(crt, art, ax, ay, crh, arh)
                            let b = Node(blt, clt, bx, by, blh, clh)
                            Node(b, a, cx, cy, height b, height a)                
            else tree
                            

    let rec private add tree key value = 
        match tree with
        | Empty -> Node(Empty, Empty, key, value, 0, 0)
        | Node(lt,rt,x,y,lh,rh) -> 
            if x < key then
                Node(balance (add lt key value),rt,x,y,lh + 1,rh)
            elif x > key then
                Node(lt,balance (add rt key value),x,y,lh,rh + 1)
            else
                Node(lt,rt,key,value,lh,rh)
                
                
        
                
    type Map<[<EqualityConditionalOn>]'Key, [<EqualityConditionalOn;ComparisonConditionalOn>]'Value when 'Key : comparison>private(tree: Tree<'key, 'value>) =
        /// <summary>Returns a new map with the binding added to the given map.</summary>
        /// <param name="key">The input key.</param>
        /// <returns>The resulting map.</returns>
        member this.Add(key:'Key, value:'Value) = new Map<_,_>(add tree key value)
  
        /// <summary>Returns true if there are no bindings in the map.</summary>
        member this.IsEmpty : bool =
            match tree with
            | Empty -> true
            | Node(_,_,_,_,_,_) -> false
  
        /// <summary>Tests if an element is in the domain of the map.</summary>
        /// <param name="key">The input key.</param>
        /// <returns>True if the map contains the given key.</returns>
        member this.ContainsKey (key:'Key) =
            let rec containsKey tree key =
                match tree with
                | Empty -> false
                | Node(a, b, x, y, _, _) -> if x = key then true
                                            else containsKey a key || containsKey b x
            containsKey tree key

        /// <summary>The number of bindings in the map.</summary>
        member this.Count : int =
            let rec count tree = 
                match tree with
                | Empty -> 0
                | Node(a,b,_,_,_,_) -> 1 + count a + count b
            count tree
 
        /// <summary>Lookup an element in the map. Raise <c>KeyNotFoundException</c> if no binding
        /// exists in the map.</summary>
        /// <param name="key">The input key.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Thrown when the key is not found.</exception>
        /// <returns>The value mapped to the key.</returns>
        member this.Item (key: 'key) =
            let rec item tree key =
                match tree with
                | Empty -> failwith "Key not found"
                | Node(a,b,x,y,_,_) -> if key = x then y
                                            elif key > x then item b key
                                            else item a key
            item tree key

        /// <summary>Removes an element from the domain of the map. No exception is raised if the element is not present.</summary>
        /// <param name="key">The input key.</param>
        /// <returns>The resulting map.</returns>
        member this.Remove (key:'Key) : Map<'Key,'Value> =
            let rec cutMin tree = 
                match tree with
                | Empty -> failwith "Right subTree is empty"
                | Node(l, r, x, y,_, rh) -> 
                    match l with
                    | Empty -> (x, y, r)
                    | Node(_,_,_,_,_,_) ->
                        match cutMin l with
                        | (a, b, t) ->
                            (a, b, balance (Node(t, r, x, y, height t, rh)))

            let deleteNode tree = 
                match tree with
                | Empty -> Empty
                | Node(l, r, x, y, lh, rh) -> 
                    match r with
                    | Empty -> l
                    | Node(_,_,_,_,_,_) -> 
                        match cutMin r with
                        | (a,b,t) -> Node(l, t, a, b, lh, height t)
                    
            let rec remove tree key =
                match tree with
                | Empty -> Empty
                | Node(l, r, x, y, lh, rh) -> 
                    if x = key then
                        balance (deleteNode tree)
                    elif key > x then 
                        let t = remove r key
                        balance (Node(l, t, x, y, lh, height t))
                    else
                        let t = remove l key
                        balance (Node(t, r, x, y, height t, rh))

            Map<_,_>(remove tree key)
 
        /// <summary>Lookup an element in the map, returning a <c>Some</c> value if the element is in the domain
        /// of the map and <c>None</c> if not.</summary>
        /// <param name="key">The input key.</param>
        /// <returns>The mapped value, or None if the key is not in the map.</returns>
        member this.TryFind (key:'Key) : 'Value option =
            let rec tryFind tree key =
                match tree with
                | Empty -> None
                | Node(l, r, x, y,_,_) -> 
                    if key = x then Some y
                    elif key > x then
                        tryFind r key
                    else
                        tryFind l key
            tryFind tree key

        //TODO:
        //override this.ToString () =
        
        //override Equals : obj -> bool                   
        
 
        //inherit IEnumerable<KeyValuePair<'Key, 'Value>>        
        
        
        /// <summary>Builds a map that contains the bindings of the given IEnumerable.</summary>
        /// <param name="elements">The input sequence of key/value pairs.</param>
        /// <returns>The resulting map.</returns>
        //new : elements:seq<'Key * 'Value> -> Map<'Key,'Value>
        
        //Optional:
        //inherit IDictionary<'Key, 'Value>        
        //inherit ICollection<KeyValuePair<'Key, 'Value>>
        //inherit System.IComparable
        //inherit System.Collections.IEnumerable