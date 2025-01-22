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
        let computedIndex = index matrix row col
        let expectedIndex = 5
        Assert.That(computedIndex, Is.EqualTo(expectedIndex))

    // Test 2: Indexing with row=2, col=2, should return index 8
    [<Test>]
    member this.Index_ShouldReturnCorrectIndex2 () =
        let matrix = create 3 3 (fun i -> i + 1)
        let row = 2
        let col = 2
        let computedIndex = index matrix row col
        let expectedIndex = 8
        Assert.That(computedIndex, Is.EqualTo(expectedIndex))

    // Test 3: Indexing with row=0, col=0, should return index 0 (zero-based)
    [<Test>]
    member this.Index_ShouldReturnZeroBasedIndex () =
        let matrix = create 3 3 (fun i -> i + 1)
        let row = 0
        let col = 0
        let computedIndex = index matrix row col
        let expectedIndex = 0
        Assert.That(computedIndex, Is.EqualTo(expectedIndex))

    // Test 4: Indexing with out-of-bounds column (col=3), should throw ArgumentException
    [<Test>]
    member this.Index_ShouldThrowArgumentException_WhenColIsOutOfRange () =
        let matrix = create 3 3 (fun i -> i + 1)
        let row = 1
        let col = 3  // Out of bounds
        Assert.Throws<ArgumentException>(fun () -> index matrix row col |> ignore) |> ignore

    // Test 5: Indexing with out-of-bounds row (row=-1), should throw ArgumentException
    [<Test>]
    member this.Index_ShouldThrowArgumentException_WhenRowIsOutOfRange () =
        let matrix = create 3 3 (fun i -> i + 1)
        let row = -1  // Out of bounds
        let col = 1
        Assert.Throws<ArgumentException>(fun () -> index matrix row col |> ignore) |> ignore

    // Test 6: Indexing with row and col equal to matrix dimensions (should throw for row=3)
    [<Test>]
    member this.Index_ShouldThrowArgumentException_WhenRowIsEqualToMaxRow () =
        let matrix = create 3 3 (fun i -> i + 1)
        let row = 3  // Out of bounds (should be [0, 2])
        let col = 0
        Assert.Throws<ArgumentException>(fun () -> index matrix row col |> ignore) |> ignore
        
    
    // Test 7: Empty Matrix (0x0) - should handle gracefully (possibly throw a custom exception or return None)
    [<Test>]
    member this.Index_ShouldThrowArgumentException_ForEmptyMatrix () =
        let matrix = create 0 0 (fun _ -> 0)
        let row = 0
        let col = 0
        Assert.Throws<ArgumentException>(fun () -> index matrix row col |> ignore) |> ignore

    // Test 8: Single-Element Matrix (1x1) - should return 0 when indexing
    [<Test>]
    member this.Index_ShouldReturnCorrectIndexForSingleElementMatrix () =
        let matrix = create 1 1 (fun _ -> 10)
        let row = 0
        let col = 0
        let computedIndex = index matrix row col
        let expectedIndex = 0
        Assert.That(computedIndex, Is.EqualTo(expectedIndex))

    // Test 9: Rectangular Matrix (3x2) - indexing should work correctly
    [<Test>]
    member this.Index_ShouldReturnCorrectIndexForRectangularMatrix () =
        let matrix = create 3 2 (fun i -> 1)
        let row = 2
        let col = 1
        let computedIndex = index matrix row col
        let expectedIndex = 5
        Assert.That(computedIndex, Is.EqualTo(expectedIndex))

    // Test 10: Large Matrix (100x100) - Test performance and correctness
    [<Test>]
    member this.Index_ShouldHandleLargeMatrix () =
        let matrix = create 100 100 (fun i -> i + 1)
        let row = 99
        let col = 99
        let computedIndex = index matrix row col
        let expectedIndex = 9999
        Assert.That(computedIndex, Is.EqualTo(expectedIndex))