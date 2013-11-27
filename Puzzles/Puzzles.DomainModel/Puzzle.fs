namespace Puzzles.DomainModel

type Utils =
    static member CombineText x y = x + System.Environment.NewLine + "\t" + y
    // LMD> Somehow need to curry/partially apply String.concat with my seeded spearator = NewLine
    ////static member PrettyPrintDescription string seq = List.reduce Utils.CombineText 

type BigOh(expression : string) =
    member this.Expression = expression

[<RequireQualifiedAccess>]
module Algorithms =
    [<RequireQualifiedAccess>]
    type Description =
        | Sorting of isStable:bool * averageCase:BigOh * worstCase:BigOh
        | Hashing
        | Compression
        override this.ToString() =
            match this with
                | Sorting(isStable, averageCase, _) -> sprintf "%s sorting with worst case %s" (if isStable then "stable" else "unstable") averageCase.Expression
                | _ -> "TO BE DESCRIBED LATER"


    type Algorithm(name:string, description:Description) =
        member this.Name = name
        member this.Title = sprintf "Algorithm: %s" this.Name
        member this.Description = description
        override this.ToString() =
            Utils.CombineText this.Title (this.Description.ToString())

[<RequireQualifiedAccess>]
module DataStructures =
    [<RequireQualifiedAccess>]
    type Description =
    | Linear
    | Trees
    | Hashes
    | Graphs

    type DataStructure(name:string, description:Description) =
        member this.Name = name
        member this.Title = sprintf "Data structure: %s" this.Name
        member this.Description = description
        override this.ToString() =
            Utils.CombineText this.Title (this.Description.ToString())

[<RequireQualifiedAccess>]
module ProjectEuler =

    [<RequireQualifiedAccess>]
    type Description =
    | Simple of string
    | WithAlgorithms of Description * algorithmsInvolved:Algorithms.Algorithm seq
    | WithDataStructures of Description * dataStructuresInvolved:DataStructures.DataStructure seq

    type Problem(id:int, description:Description) =
        member this.Id = id
        member this.Title = sprintf "Project Euler #%d" id
        member this.Description = description
        override this.ToString() =
            Utils.CombineText this.Title (this.Description.ToString())

[<RequireQualifiedAccess>]
module Puzzle =
    type Identifier =
        | GeneralMathematical of name:string * description:string
        | GeneralLogic of name:string * description:string
        | ProjectEuler of ProjectEuler.Problem
        | DataStructure of DataStructures.DataStructure
        | Algorithm of Algorithms.Algorithm
        override this.ToString() =
            match this with
                | GeneralMathematical(name, description) -> description |>  Utils.CombineText(sprintf "General math problem: %s" name)
                | GeneralLogic(name, description) -> Utils.CombineText (sprintf "General logic problem: %s" name) description
                | ProjectEuler(proper) -> proper.ToString()
                | DataStructure(proper) -> proper.ToString()
                | Algorithm(proper) -> proper.ToString()

