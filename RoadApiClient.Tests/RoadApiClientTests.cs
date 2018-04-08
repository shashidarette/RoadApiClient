using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoadApiClient.Tests
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

    [TestClass]
    public class RoadApiClientTests
    {
        [TestMethod]
        public void Check_ValidRoad_Output_Test()
        {
        }

        [TestMethod]
        public void Check_InvalidRoad_Output_Test()
        {
        }
    }
}
