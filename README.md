# TfL Road api client
This project is a command client to communicate with TfL Unified API.
As of now the client only focus on Road Status API. 

The source code is strutured as below:
* RoadApi.Library - This is the core library responsible for communication with TfL Road api. It only implements GetStatus operation to get status of a road.
* RoadApi.Library.Tests - This is the tests project covers the tests for RoadApi.Library. The tests only cover the basic requirements mentioned in the RoadStatusTests.cs.
* RoadStatus - This is the command client application. It consumes RoadApi.Library to get status of the road. The client processes the arguments passed by the user and informs the status of road.
* RoadApiClent.Tests - This is the test project for RoadStatus command application.

The client has been developed using VS 2015, C# and .Net framework is v4.6.1. It uses Newtonsoft.Json package for JSon operations and  DTOs provided by TfL i.e. Tfl.Api.Presentation.Entities.dll.

RoadApi.Library.Tests and RoadStatus have App.config. It provides <b>TflAppId</b> and <b>TflAppKey</b> application settings. These need to be updated with the relevant developer keys provided by https://api.tfl.gov.uk/. If the keys are not updated, an error message will be sent. 
