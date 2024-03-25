``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19045
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK=9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT


```
|     Method |  Size |     Mean |     Error |    StdDev | Ratio |
|----------- |------ |---------:|----------:|----------:|------:|
|   Original | 32768 | 9.925 μs | 0.1707 μs | 0.1513 μs |  1.00 |
| Vectorized | 32768 | 1.643 μs | 0.0286 μs | 0.0238 μs |  0.17 |
