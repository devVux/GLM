namespace GLM

open MatrixModule
open System

module Transformations = 

    let index (m: Matrix<'T>) row col =
        if row < 0 || row >= m.Rows then
            raise (ArgumentException(sprintf "row should be [0, %d], but was %d" (m.Rows - 1) row))
        else if col < 0 || col >= m.Cols then
            raise (ArgumentException(sprintf "col should be [0, %d], but was %d" (m.Cols - 1) col))
        else 
            row * m.Cols + col
 