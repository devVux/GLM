namespace GLM

open MatrixModule
open System

module Transformations = 

    let transpose (m: Matrix<'T>) =
        let tr = create m.Cols m.Rows (fun i -> 
            let row, col = fromIndex m.Rows i
            m.Data[toIndex m.Cols col row]
        )

        tr
  
