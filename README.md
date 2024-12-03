# CheckAlphabetWebAPI

This repository contains the CheckAlphabetWebAPI, a RESTful Web API built in C# using .NET Core that determines if an input string contains all the letters of the English alphabet. It provides a simple endpoint to validate the input and returns true or false.

# Features
RESTful API built with .NET Core.
Endpoint to check if a string contains all letters of the English alphabet.
Deployed using Azure Kubernetes Service (AKS) and Azure Container Registry (ACR).
Dockerized for easy deployment.

# API Endpoint
GET /api/alphabetchecker/check
Query Parameter: input (string) - The input string to check.
Response: Returns true if the string contains all English alphabet letters, otherwise false.

Example
Request: 
GET /api/alphabetchecker/check?input=The%20quick%20brown%20fox%20jumps%20over%20the%20lazy%20dog
Response:
true

# Deployment Strategy
This guide explains how to deploy the CheckAlphabetWebAPI into Azure Cloud using Azure Kubernetes Service (AKS) and Azure Container Registry (ACR).

Prerequisites
An Azure account.
Azure Kubernetes Service (AKS) cluster.
Azure Container Registry (ACR) set up.
Docker installed locally.
Kubernetes CLI (kubectl) installed locally.

# Steps

Step 1: Build and Tag the Docker Image
Build the Docker image for the Web API:
docker build -t check-alphabet-api .

Tag the Docker image with the ACR name:
docker tag check-alphabet-api <azurecontainerregistry_name>.azurecr.io/check-alphabet-api:latest
e

Step 2: Push the Image to Azure Container Registry
Push the tagged image to the Azure Container Registry:
docker push <azurecontainerregistry_name>.azurecr.io/check-alphabet-api:latest

Step 3: Create Kubernetes Deployment and Service Files
Ensure the repository contains the following Kubernetes configuration files:
deployment.yaml - Defines the deployment configuration.
service.yaml - Defines the load balancer service configuration.

Step 4: Deploy to Azure Kubernetes Service
Use the kubectl command-line tool to apply the Kubernetes configurations:

Deploy the application:
kubectl apply -f deployment.yaml

Deploy the load balancer service:
kubectl apply -f service.yaml

Files in the Repository
README.md: Documentation of the API and deployment steps.
deployment.yaml: Kubernetes Deployment configuration file.
service.yaml: Kubernetes Service configuration file.
Source Code: Contains the Web API source code in the CheckAlphabetWebAPI.

# Testing the Deployed API

Once the deployment is complete, get the external IP of the service:
kubectl get service

Use the provided external IP to make API requests:
GET http://<external-ip>/api/alphabetchecker/check?input=your-string

Contributing
Contributions are welcome! Please create a pull request or open an issue for any improvements or bug fixes.

