# AllocationVerification-Unity
Allocation verifications in Unity C#

## Tests
### AllocationTests
Tests to verify allocations in C#.

- Passed tests have no allocations
- Failed tests have any allocations

### Tests
Tests to verify features, so they will pass exactly unlike AllocationTests.

## Notes
- You chan use `Contains` method for `IReadOnlyList` with [TSCSharpSystemExtension](https://github.com/tsgcpp/TSCSharpSystemExtension)
