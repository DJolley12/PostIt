#This is a WIP, not yet ready for use

#PostIt

PostIt is a native client for testing API's-think postman and friends, but for the terminal

##Features

-Create and save requests for API endpoints

-Create tests for API endpoints, this allows you to specify desired feedback and outcomes for API endpoints
    Tests are essentially a request paired with a desired response, and http status code

-Create flows
    Flows are groups of tests, with specific paramters to grab, and pass to the next test.
    Use case examples: 
       Test a login, pass the token to the next request. 
       Test a group of requests that have interdependent response parameters


