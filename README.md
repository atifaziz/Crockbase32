# Crockbase32

This is a C# implementation of Base 32 based on the [scheme described by
Douglas Crockford][spec]. It uses a symbol set of 10 digits and 22 uppercase.
Letter U is not allowed; letters I and L are treated the same as 1 and O is
treated the same as 0.

This implementation does not support check symbols that are otherwise defined
for the purpose of detecting wrong-symbol and transposed-symbol errors.


## Usage

Include `Crockbase32.cs` in your project.


## Examples

To encode a _byte string_ (where all characters are in the range 0 to 255):

```c#
var encoded = Crockbase32.EncodeByteString("foobar");
Console.WriteLine(encoded);
// prints CSQPYRK1E8
```

To decode:

```c#
var decoded = Crockbase32.Decode("CSQPYRK1E8");
Console.WriteLine(string.Join(",", decoded));
// prints 102,111,111,98,97,114
```


## Symbols

| Symbol Value | Decode Symbol | Encode Symbol |
|:------------:|:-------------:|:-------------:|
|       0      |     0 O o     |       0       |
|       1      |   1 I i L l   |       1       |
|       2      |       2       |       2       |
|       3      |       3       |       3       |
|       4      |       4       |       4       |
|       5      |       5       |       5       |
|       6      |       6       |       6       |
|       7      |       7       |       7       |
|       8      |       8       |       8       |
|       9      |       9       |       9       |
|      10      |      A a      |       A       |
|      11      |      B b      |       B       |
|      12      |      C c      |       C       |
|      13      |      D d      |       D       |
|      14      |      E e      |       E       |
|      15      |      F f      |       F       |
|      16      |      G g      |       G       |
|      17      |      H h      |       H       |
|      18      |      J j      |       J       |
|      19      |      K k      |       K       |
|      20      |      M m      |       M       |
|      21      |      N n      |       N       |
|      22      |      P p      |       P       |
|      23      |      Q q      |       Q       |
|      24      |      R r      |       R       |
|      25      |      S s      |       S       |
|      26      |      T t      |       T       |
|      27      |      V v      |       V       |
|      28      |      W w      |       W       |
|      29      |      X x      |       X       |
|      30      |      Y y      |       Y       |
|      31      |      Z z      |       Z       |

Hyphens (`-`) can be inserted into symbol strings. This can partition a string
into manageable pieces, improving readability by helping to prevent confusion.
Hyphens are ignored during decoding.


[spec]: https://www.crockford.com/base32.html
