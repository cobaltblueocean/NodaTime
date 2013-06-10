// Copyright 2009 The Noda Time Authors. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using System;
using NUnit.Framework;
using NodaTime.Fields;

namespace NodaTime.Test.Fields
{
    [TestFixture]
    public class FixedLengthPeriodFieldTest
    {
        private FixedLengthPeriodField field;

        [SetUp]
        public void SetUp()
        {
            field = new FixedLengthPeriodField(PeriodFieldType.Milliseconds, NodaConstants.TicksPerMillisecond);
        }

        [Test]
        public void Constructor_WithInvalidType_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new FixedLengthPeriodField((PeriodFieldType)(-1), 10));
        }

        [Test]
        public void FieldType()
        {
            Assert.AreEqual(PeriodFieldType.Milliseconds, field.FieldType);
        }

        [Test]
        public void IsFixedLength_ReturnsTrue()
        {
            Assert.IsTrue(field.IsFixedLength);
        }

        [Test]
        public void UnitTicks()
        {
            Assert.AreEqual(NodaConstants.TicksPerMillisecond, field.UnitTicks);
        }

        [Test]
        public void GetValue_WithLocalInstant()
        {
            LocalInstant when = new LocalInstant(987654321L);
            Assert.AreEqual(0, field.GetValue(new Duration(0L), when));
            Assert.AreEqual(12345, field.GetValue(new Duration(123456789L), when));
            Assert.AreEqual(-1, field.GetValue(new Duration(-12345L), when));
        }

        [Test]
        public void GetValue_WithLocalInstant_ThrowsOnOverflow()
        {
            LocalInstant when = new LocalInstant(987654321L);
            Assert.Throws<OverflowException>(() => field.GetValue(new Duration(int.MaxValue * 10000L + 10000L), when));
        }

        [Test]
        public void GetInt64Value_WithLocalInstant()
        {
            LocalInstant when = new LocalInstant(987654321L);
            Assert.AreEqual(0, field.GetInt64Value(new Duration(0L), when));
            Assert.AreEqual(12345, field.GetInt64Value(new Duration(123456789L), when));
            Assert.AreEqual(-1, field.GetInt64Value(new Duration(-12345L), when));
            Assert.AreEqual(int.MaxValue + 1L, field.GetInt64Value(new Duration(int.MaxValue * 10000L + 10000L), when));
        }

        [Test]
        public void GetDuration()
        {
            Assert.AreEqual(0L, field.GetDuration(0).Ticks);
            Assert.AreEqual(12340000L, field.GetDuration(1234).Ticks);
            Assert.AreEqual(-12340000L, field.GetDuration(-1234).Ticks);
            Assert.AreEqual(int.MaxValue * 10000L, field.GetDuration(int.MaxValue).Ticks);
        }

        [Test]
        public void GetDuration_ThrowsOnOverflow()
        {
            Assert.Throws<OverflowException>(() => field.GetDuration(long.MaxValue));
        }

        [Test]
        public void GetDuration_WithLocalInstant()
        {
            LocalInstant when = new LocalInstant(987654321L);
            Assert.AreEqual(0L, field.GetDuration(0, when).Ticks);
            Assert.AreEqual(12340000L, field.GetDuration(1234, when).Ticks);
            Assert.AreEqual(-12340000L, field.GetDuration(-1234, when).Ticks);
            Assert.AreEqual(int.MaxValue * 10000L, field.GetDuration(int.MaxValue, when).Ticks);
        }

        [Test]
        public void GetDuration_WithLocalInstant_ThrowsOnOverflow()
        {
            LocalInstant when = new LocalInstant(987654321L);
            Assert.Throws<OverflowException>(() => field.GetDuration(long.MaxValue, when));
        }

        [Test]
        public void Add_WithInt32Value()
        {
            LocalInstant when = new LocalInstant(567L);
            Assert.AreEqual(567L, field.Add(when, 0).Ticks);
            Assert.AreEqual(567L + 12340000L, field.Add(when, 1234).Ticks);
            Assert.AreEqual(567L - 12340000L, field.Add(when, -1234).Ticks);
        }

        [Test]
        public void Add_WithInt32Value_ThrowsOnOverflow()
        {
            Assert.Throws<OverflowException>(() => field.Add(new LocalInstant(long.MaxValue), 1));
        }

        [Test]
        public void Add_WithInt64Value()
        {
            LocalInstant when = new LocalInstant(567L);
            Assert.AreEqual(567L, field.Add(when, 0L).Ticks);
            Assert.AreEqual(567L + 12340000L, field.Add(when, 1234L).Ticks);
            Assert.AreEqual(567L - 12340000L, field.Add(when, -1234L).Ticks);
        }

        [Test]
        public void Add_WithInt64Value_ThrowsOnOverflow()
        {
            Assert.Throws<OverflowException>(() => field.Add(new LocalInstant(long.MaxValue), 1));
            Assert.Throws<OverflowException>(() => field.Add(new LocalInstant(0), long.MaxValue));
        }

        [Test]
        public void GetDifference()
        {
            Assert.AreEqual(0, field.GetDifference(new LocalInstant(1), new LocalInstant(0)));
            Assert.AreEqual(567, field.GetDifference(new LocalInstant(5670000L), new LocalInstant(0)));
            Assert.AreEqual(567 - 1234, field.GetDifference(new LocalInstant(5670000L), new LocalInstant(12340000L)));
            Assert.AreEqual(567 + 1234, field.GetDifference(new LocalInstant(5670000L), new LocalInstant(-12340000L)));
        }

        [Test]
        public void GetDifference_ThrowsOnOverflow()
        {
            Assert.Throws<OverflowException>(() => field.GetDifference(new LocalInstant(long.MaxValue), new LocalInstant(-1L)));
            Assert.Throws<OverflowException>(() => field.GetDifference(new LocalInstant(int.MaxValue * 10000L), new LocalInstant(-10000L)));
        }

        [Test]
        public void GetInt64Difference()
        {
            Assert.AreEqual(0L, field.GetInt64Difference(new LocalInstant(1), new LocalInstant(0)));
            Assert.AreEqual(567L, field.GetInt64Difference(new LocalInstant(5670000L), new LocalInstant(0)));
            Assert.AreEqual(567L - 1234L, field.GetInt64Difference(new LocalInstant(5670000L), new LocalInstant(12340000L)));
            Assert.AreEqual(567L + 1234L, field.GetInt64Difference(new LocalInstant(5670000L), new LocalInstant(-12340000L)));
            Assert.AreEqual(int.MaxValue + 1L, field.GetInt64Difference(new LocalInstant(int.MaxValue * 10000L), new LocalInstant(-10000L)));
        }

        [Test]
        public void GetInt64Difference_ThrowsOnOverflow()
        {
            Assert.Throws<OverflowException>(() => field.GetInt64Difference(new LocalInstant(long.MaxValue), new LocalInstant(-1L)));
        }
    }
}