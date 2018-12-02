# APIGateway [![CircleCI](https://circleci.com/gh/NielsB95/APIGateway/tree/master.svg?style=svg)](https://circleci.com/gh/NielsB95/APIGateway/tree/master)
In this repository, you'll find an API Gateway which can be used in a microservice architecture. The number of microservices in your application is inevitably going to increase. With this increase, it will become more difficult for your client applications to find the correct address for each microservice. Especially, if the location of these microservices changes sometimes.

To make it more easy to send requests to a microservice-based application, gateways are used as a central entry point. An API Gateway accepts all requests and forwards them to the right microservice. Your client application only needs to talk with the gateway for usage of all microservice functionalities.

In this implementation, the API gateway takes care of service registration. Moreover, it will check regularly if the microservices are all still alive and healthy.

This APIGateway has been built with .Net Core 2.1.6

![API Gateway](https://drive.google.com/uc?export=view&id=15GQSh66ocxa80OKcIgFUKBxcwK9fsn-A)
