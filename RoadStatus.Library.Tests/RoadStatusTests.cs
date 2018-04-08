﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoadApi.Library;

namespace RoadApi.Library.Tests
{
    /**
     * This test class details the tests for the requirements of RoadStatus client.
     * The scope of the client is to check the validity of road based on the id.
     * In addition it should also retrieve basic informaiton such as Display Name (different from RoadID),
     * Status and StatusDescription.
     * */
    [TestClass]
    public class RoadStatusTests
    {
        //Given a valid road ID is specified
        //When the client is run
        //Then the road ‘displayName’ should be displayed

        //Given a valid road ID is specified
        //When the client is run
        //Then the road ‘statusSeverity’ should be displayed as ‘Road Status’

        //Given a valid road ID is specified
        //When the client is run
        //Then the road ‘statusSeverityDescription’ should be displayed as ‘Road Status Description’

        //Given an invalid road ID is specified
        //When the client is run
        //Then the application should return an informative error

        //Given an invalid road ID is specified
        //When the client is run
        //Then the application should exit with a non-zero System Error code

        [TestMethod]
        public void Check_ValidRoadStatus_Test()
        {
            RoadInformation status = RoadStatus.GetStatus("A1");
            Assert.IsTrue(status.Valid);
        }

        [TestMethod]
        public void Check_InvalidRoadStatus_Test()
        {
            RoadInformation status = RoadStatus.GetStatus("A1000");
            Assert.IsFalse(status.Valid);
        }

        [TestMethod]
        public void Check_ValidRoadStatus_DisplayName_Test()
        {
            RoadInformation status = RoadStatus.GetStatus("A1");
            Assert.IsNotNull(status.Name);
        }

        [TestMethod]
        public void Check_ValidRoadStatus_Status_Test()
        {
            RoadInformation status = RoadStatus.GetStatus("A1");
            Assert.IsNotNull(status.StatusSeverity);
        }

        [TestMethod]
        public void Check_ValidRoadStatus_StatusDescription_Test()
        {
            RoadInformation status = RoadStatus.GetStatus("A1");
            Assert.IsNotNull(status.StatusSeverityDescription);
        }

        [TestMethod]
        public void Check_InvalidRoadStatus_ErrorMessage_Test()
        {
            RoadInformation status = RoadStatus.GetStatus("A1000");
            Assert.IsNotNull(RoadStatus.LastErrorMessage);
        }

        [TestMethod]
        public void Check_InvalidRoadStatus_ErrorCode_Test()
        {
            RoadInformation status = RoadStatus.GetStatus("A1000");
            Assert.IsNotNull(RoadStatus.LastErrorCode);
        }
    }
}
