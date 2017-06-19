﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Fnv1a256Tests.cs" company="Always Elucidated Solution Pioneers, LLC">
//   Copyright © Always Elucidated Solution Pioneers, LLC 2014
// </copyright>
// <summary>
//   Tests the FNV-1a 256-bit algorithm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Fnv1aTests
{
    using System.Numerics;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static System.Globalization.CultureInfo;
    using static System.Globalization.NumberStyles;
    using static System.Numerics.BigInteger;
    using static System.Text.Encoding;

    using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    /// <summary>
    /// Tests the FNV-1a 256-bit algorithm.
    /// </summary>
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public sealed class Fnv1a256Tests
    {
        /// <summary>
        /// Tests the empty string against the known vector result.
        /// </summary>
        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void TestVector1()
        {
            AreEqual(
                Parse("0DD268DBCAAC550362D98C384C4E576CCC8B1536847B6BBB31023B4C8CAEE0535", AllowHexSpecifier, InvariantCulture),
                Fnv1a256(string.Empty));
        }

        /// <summary>
        /// Tests the string "a" against the known vector result.
        /// </summary>
        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void TestVector2()
        {
            AreEqual(
                Parse("03323FB0F35303EC28DC751D0A33BDFA4DE6A99B7266494F6183B2716811637C", AllowHexSpecifier, InvariantCulture),
                Fnv1a256("a"));
        }

        /// <summary>
        /// Tests the string against the known vector result.
        /// </summary>
        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void TestVector3()
        {
            AreEqual(
                Parse("0055EA2F306CADAD4F0F81C02D3889DC32453DAD5AE35B753BA1A91084AF3428", AllowHexSpecifier, InvariantCulture),
                Fnv1a256("foobar"));
        }

        /// <summary>
        /// Computes the FNV-1a 256-bit hash for the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The FNV-1a 256-bit hash of the specified data.</returns>
        // ReSharper disable once InconsistentNaming
        private static BigInteger Fnv1a256(string data)
        {
            using (System.Security.Cryptography.HashAlgorithm alg = new Fnv1a.Fnv1a256())
            {
                AreEqual(256, alg.HashSize);
                return new BigInteger(alg.ComputeHash(UTF8.GetBytes(data)));
            }
        }
    }
}
