﻿// Copyright 2014 The Noda Time Authors. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.
using System;
using NodaTime.Utility;
using NUnit.Framework;

namespace NodaTime.Test.Utility
{
    public class PreconditionsTest
    {
        // This overload is only called from one place, and only when it's going to fail...
        [Test]
        public void CheckArgument2_Success()
        {
            Preconditions.CheckArgument(true, "param", "{0} is {1}", 1, 10);
        }

        [Test]
        public void CheckArgument2_Failure()
        {
            var exception = Assert.Throws<ArgumentException>(() => Preconditions.CheckArgument(false, "param", "{0} is {1}", 1, 10))!;
            Assert.AreEqual("param", exception.ParamName);
            Assert.IsTrue(exception.Message.Contains("1 is 10"));
        }

        // It's really not worth inventing parameters for these...
#pragma warning disable InvokerParameterName
#pragma warning disable NotNullCheckWithoutParameter
#if DEBUG
        [Test]
        public void DebugCheckArgumentRange_Debug()
        {
            Preconditions.DebugCheckArgumentRange("ignore", 5, 0, 10);
            Preconditions.DebugCheckArgumentRange("ignore", 5L, 0L, 10L);
            Assert.Throws<DebugPreconditionException>(() => Preconditions.DebugCheckArgumentRange("ignore", 10, 0, 5));
            Assert.Throws<DebugPreconditionException>(() => Preconditions.DebugCheckArgumentRange("ignore", 10L, 0L, 5L));
        }

        [Test]
        public void DebugCheckNotNull_Debug()
        {
            Preconditions.DebugCheckNotNull("value", "ignore");
            Assert.Throws<DebugPreconditionException>(() => Preconditions.DebugCheckNotNull((string) null!, "ignore"));
        }
#else
        [Test]
        public void DebugCheckArgumentRange_NotDebug()
        {
            Preconditions.DebugCheckArgumentRange("ignore", 5, 0, 10);
            Preconditions.DebugCheckArgumentRange("ignore", 5L, 0L, 10L);
            Preconditions.DebugCheckArgumentRange("ignore", 10, 0, 5);
            Preconditions.DebugCheckArgumentRange("ignore", 10L, 0L, 5L);
        }

        [Test]
        public void DebugCheckNotNull_NotDebug()
        {
            Preconditions.DebugCheckNotNull("value", "ignore");
            Preconditions.DebugCheckNotNull((string) null!, "ignore");
        }
#endif
    }
}
#pragma warning restore InvokerParameterName