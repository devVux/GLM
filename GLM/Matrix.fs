namespace GLM

module MatrixModule =
    type Matrix<'T> = { Rows: int; Cols: int; Data: 'T array}

    let create rows cols initializer = 
        { Rows = rows; Cols = cols; Data = Array.init (rows * cols) initializer }
        
    let square count initializer =
        create count count initializer

    let identity count = 
        create count count (fun i -> if i % (count + 1) = 0 then 1 else 0)

    let zeros rows cols = 
        create rows cols (fun _ -> 0)

    let ones rows cols = 
        create rows cols (fun _ -> 1)
