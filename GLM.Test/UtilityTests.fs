namespace GLM_Test

open System
open NUnit.Framework
open GLM.MatrixModule
open GLM.Transformations

[<TestFixture>]
type UtilityTests () =

    // Test 1: Indexing with row=1, col=2, should return index 5
    [<Test>]
    member this.Index_ShouldReturnCorrectIndex () =
        let matrix = create 3 3 (fun i -> i + 1)
        let row = 1
        let col = 2
        let computedIndex = toIndex matrix.Cols row col
        let expectedIndex = 5
        Assert.That(computedIndex, Is.EqualTo(expectedIndex))

    // Test 2: Indexing with row=2, col=2, should return index 8
    [<Test>]
    member this.Index_ShouldReturnCorrectIndex2 () =
        let matrix = create 3 3 (fun i -> i + 1)
        let row = 2
        let col = 2
        let computedIndex = toIndex matrix.Cols row col
        let expectedIndex = 8
        Assert.That(computedIndex, Is.EqualTo(expectedIndex))

    // Test 3: Indexing with row=0, col=0, should return index 0 (zero-based)
    [<Test>]
    member this.Index_ShouldReturnZeroBasedIndex () =
        let matrix = create 3 3 (fun i -> i + 1)
        let row = 0
        let col = 0
        let computedIndex = toIndex matrix.Cols row col
        let expectedIndex = 0
        Assert.That(computedIndex, Is.EqualTo(expectedIndex))


[<TestFixture>]
type CreationalTests () =

    [<Test>]
    member this.Create_TestSquareMatrixCreationFromArray () =
        let size = 2

        let matrix = square size (fun i -> i + 1)
        let matrix2 = fromArray size size [| 1; 2; 3; 4 |]

        Assert.AreEqual(matrix, matrix2)

    [<Test>]
    member this.Create_TestRectangularMatrixCreationFromArray () =
        let rows = 3
        let cols = 2

        let matrix = create rows cols (fun i -> i + 1)
        let matrix2 = fromArray rows cols [| 1; 2; 3; 4; 5; 6 |]

        Assert.AreEqual(matrix, matrix2)



[<TestFixture>]
type TransformationTests () =

    [<Test>]
    member this.Transpose_TestSquareMatrix () =
        let size = 2

        let tr = transpose (fromArray size size [| 1; 2; 3; 4 |])
        let target = fromArray size size [| 1; 3; 2; 4 |]

        Assert.AreEqual(target, tr)

    [<Test>]
    member this.Transpose_TestRectangularMatrix () =
        let rows = 3
        let cols = 2

        let tr = transpose (fromArray rows cols [| 1; 2; 3; 4; 5; 6 |])
        let target = fromArray cols rows [| 1; 3; 5; 2; 4; 6 |]

        Assert.AreEqual(target, tr)