namespace Puzzles.DomainModel

type Utils =
    static member CombineText x y = x + System.Environment.NewLine + y
    // LMD> Somehow need to curry/partially apply String.concat with my seeded spearator = NewLine
    ////static member PrettyPrintDescription string seq = List.reduce Utils.CombineText 

type BigOh(expression : string) =
    member this.Expression = expression

module Algorithms =
    [<RequireQualifiedAccess>]
    type Description =
    | Sorting of isStable:bool * averageCase:BigOh * worstCase:BigOh
    | Hashing
    | Compression
    
    [<RequireQualifiedAccess>]
    type Algorithm(name:string, description:Description) =
        member this.Name = name
        member this.Title = sprintf "Algorithm: %s" this.Name
        member this.Description = description
        override this.ToString() =
            Utils.CombineText this.Title (this.Description.ToString())

module DataStructures =
    [<RequireQualifiedAccess>]
    type Description =
    | Linear
    | Trees
    | Hashes
    | Graphs

    [<RequireQualifiedAccess>]
    type DataStructure(name:string, description:Description) =
        member this.Name = name
        member this.Title = sprintf "Data structure: %s" this.Name
        member this.Description = description
        override this.ToString() =
            Utils.CombineText this.Title (this.Description.ToString())

module ProjectEuler =

    [<RequireQualifiedAccess>]
    type Description =
    | Simple of string
    | WithAlgorithms of Description * algorithmsInvolved:Algorithms.Algorithm seq
    | WithDataStructures of Description * dataStructuresInvolved:DataStructures.DataStructure seq

    [<RequireQualifiedAccess>]
    type Problem(id:int, description:Description) =
        member this.Id = id
        member this.Title = sprintf "Project Euler #%d" id
        member this.Description = description
        override this.ToString() =
            Utils.CombineText this.Title (this.Description.ToString())

module Puzzle =
    [<RequireQualifiedAccess>]
    type Identifier =
        | GeneralMathematical of name:string * description:string
        | GeneralLogic of name:string * description:string
        | ProjectEuler of ProjectEuler.Problem
        | DataStructure of DataStructures.DataStructure
        | Algorithm of Algorithms.Algorithm
        override this.ToString() =
            match this with
                | GeneralMathematical(name, description) -> sprintf "General math problem: %s" name
                | GeneralLogic(name, description) -> sprintf "General logic problem: %s" name
                | ProjectEuler(proper) -> proper.ToString()
                | DataStructure(proper) -> proper.ToString()
                | Algorithm(proper) -> proper.ToString()

