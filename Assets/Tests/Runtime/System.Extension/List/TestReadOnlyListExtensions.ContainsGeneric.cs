using System.Collections.Generic;
using NUnit.Framework;
using SampleType;
using System.Extension;

namespace Tests.System.Extension
{
    public sealed partial class TestReadOnlyListExtensions
    {
        public sealed class ContainsGeneric
        {
            IReadOnlyList<Foo> _target;
            IReadOnlyList<Foo> _targetWithNull;
            IReadOnlyList<Foo> _targetEmpty;

            Foo _foundItem;

            [SetUp]
            public void SetUp()
            {
                _foundItem = new Foo();

                _target = new List<Foo>
                {
                    new Foo(),
                    _foundItem,
                    new Foo(),
                };

                _targetWithNull = new List<Foo>
                {
                    new Foo(),
                    null,
                    new Foo(),
                };

                _targetEmpty = new List<Foo>();
            }

            [Test]
            public void ItemIsNull_ListWithoutNull_ReturnsFalse()
            {
                Assert.False(_target.ContainsGeneric(null));
            }

            [Test]
            public void ItemIsNull_ListWithNull_ReturnsTrue()
            {
                Assert.True(_targetWithNull.ContainsGeneric(null));
            }

            [Test]
            public void ItemIsNull_EmptyList_ReturnsFalse()
            {
                Assert.False(_targetEmpty.ContainsGeneric(null));
            }

            [Test]
            public void ItemIsNotNull_ListWithTarget_ReturnsTrue()
            {
                Assert.True(_target.ContainsGeneric(_foundItem));
            }

            [Test]
            public void ItemIsNotNull_ListWithoutTarget_ReturnsFalse()
            {
                Assert.False(_targetWithNull.ContainsGeneric(_foundItem));
            }

            [Test]
            public void ItemIsNotNull_EmptyList_ReturnsFalse()
            {
                Assert.False(_targetEmpty.ContainsGeneric(_foundItem));
            }
        }
    }
}
