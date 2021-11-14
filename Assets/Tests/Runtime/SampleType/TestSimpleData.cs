using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using SampleType;

namespace Tests.SampleType
{
    public class TestSimpleData
    {
        SimpleData _target;

        SimpleData Value => new SimpleData { value = 123 };

        [SetUp]
        public void SetUp()
        {
            _target = Value;
        }

        [Test]
        public void Equals_ReturnsTrueIfValuesAreSame()
        {
            // when
            bool actual = _target.Equals(Value);

            // then
            Assert.True(actual);
        }

        [Test]
        public void Equals_ReturnsFalseIfValuesAreNotSame()
        {
            // when
            bool actual = _target.Equals(new SimpleData { value = 987 });

            // then
            Assert.False(actual);
        }

        [Test]
        public void Equals_WithUnboxing_ReturnsTrueIfValuesAreSame()
        {
            object objValue = Value;

            // when
            bool actual = _target.Equals(objValue);

            // then
            Assert.True(actual);
        }

        [Test]
        public void Equals_WithUnboxing_ReturnsFalseIfValuesAreNotSame()
        {
            object objValue = new SimpleData { value = 987 };

            // when
            bool actual = _target.Equals(objValue);

            // then
            Assert.False(actual);
        }

        [Test]
        public void Equals_WithUnboxing_ReturnsFalseIfArgIsNull()
        {
            object objValue = null;

            // when
            bool actual = _target.Equals(objValue);

            // then
            Assert.False(actual);
        }

        [Test]
        public void Equals_WithUnboxing_ReturnsFalseIfArgTypeIsNotSame()
        {
            object objValue = 123;

            // when
            bool actual = _target.Equals(objValue);

            // then
            Assert.False(actual);
        }
    }
}
