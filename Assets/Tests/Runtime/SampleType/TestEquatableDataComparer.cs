using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using SampleType;

namespace Tests.SampleType
{
    public class TestDataComparer
    {
        EquatableDataComparer _target;

        [SetUp]
        public void SetUp()
        {
            _dataA = new EquatableData { value = 123 };
            _dataB = new EquatableData { value = 456 };

            _target = new EquatableDataComparer();
        }

        [Test]
        public void Equals_ReturnsTrueIfValuesAreSame()
        {
            Assert.True(_target.Equals(_dataA, _dataA));
        }

        [Test]
        public void Equals_ReturnsFalseIfValuesAreNotSame()
        {
            Assert.False(_target.Equals(_dataA, _dataB));
        }

        EquatableData _dataA;
        EquatableData _dataB;
    }
}
