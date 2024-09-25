.NET Engineer - Technical Assignment

Scenario:
You are working as a senior developer for a recruitment company that is expanding
its platform to include advanced data analytics features. The hiring manager wants
to record the names of people she has interviewed and whether or not she wants to
offer them a job. Additionally, she wants to analyze these decisions based on various
criteria such as candidate experience, skill set, and interview feedback.

Work done on the Solution:


First Part: Setting up the project and the database:

-Created new WebAPI project called RecruitmentAPI inside RecruitmentSolution
-Added NuGet packages for Entity Framework: EFCore, EFSqlServer, EFTools.
-Created 3 Models for start: Candidates, InterviewFeedback, Skills
-Set up appSetttings.json file with ConnectionString towards my local db server
-Set up Data folder which holds the RecruitmentContext and the models entities and their dependencies
-Based on the 3 Models with the EF help with running this in the cmd prompt:
dotnet ef migrations add InitialCreate
The DB Schema with the 3 tables has been created.
-Start to implement the necessary CRUD operations for the first task of the assignment about Candidate Management:
-Created Candidates controller with all the endpoints GET, POST, PUT, DELETE.
-Make it possible to Filter the GET endpoint by Skill, Years of Experience or Hired or not.

Second Part: UmbracoCMS integration
-Setting up a new Umbraco project. Implementing necessary dotnet packages to build and run the Umbraco locally (dotnet run in the cmd prompt). Created a new account and logged in UmbracoCMS.
-UmbracoCMS Setup: You have created a document type for Candidate with properties for fields like candidateName and a checkbox list for Skills.
-Exposing REST API endpoints 
GET https://localhost:{port}/umbraco/api/candidateapi/getcandidates
CREATE https://localhost:{port}/umbraco/api/candidateapi/createcandidates/{id}
{
    "name": "New Candidate",
    "skills": ["C#", "Umbraco", "SQL"]
}
PUT https://localhost:{port}/umbraco/api/candidateapi/updatecandidates/{id}
DELETE https://localhost:{port}/umbraco/api/candidateapi/deletecandidates/{id}


Third Part: Power BI

-Implemented Statistics controller which exposes these endpoints:
Total Candidates Count: GET statistics/total
Job Offers vs Rejections: GET statistics/decisions
Average Experience: GET statistics/averageexperience
Top Skills: GET statistics/topskills
-Created a Dashboard with charts representing the data.


First Part version 2:
-Introducing layered architecture into the project.
-Implementing Core, BusinessLayer, DataLayer as class libraries.
-Fixing all the dependencies and proper handling of the Database connection.