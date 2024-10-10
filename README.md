<h2>.NET Engineer - Technical Assignment</h2>

Scenario:
You are working as a senior developer for a recruitment company that is expanding
its platform to include advanced data analytics features. The hiring manager wants
to record the names of people she has interviewed and whether or not she wants to
offer them a job. Additionally, she wants to analyze these decisions based on various
criteria such as candidate experience, skill set, and interview feedback.


<h3>First Part: Setting up the project and the database:</h3>

-Created new WebAPI project called RecruitmentAPI inside RecruitmentSolution <br/>
-Added NuGet packages for Entity Framework: EFCore, EFSqlServer, EFTools. <br/>
-Created 3 Models for start: Candidates, InterviewFeedback, Skills <br/>
-Set up appSetttings.json file with ConnectionString towards my local db server <br/>
-Set up Data folder which holds the RecruitmentContext and the models entities and their dependencies <br/>
-Based on the 3 Models with the EF help with running this in the cmd prompt: <br/>
dotnet ef migrations add InitialCreate <br/>
The DB Schema with the 3 tables has been created. <br/>
-Start to implement the necessary CRUD operations for the first task of the assignment about Candidate Management: <br/>
-Created Candidates controller with all the endpoints GET, POST, PUT, DELETE. <br/>
-Make it possible to Filter the GET endpoint by Skill, Years of Experience or Hired or not. <br/>

<h3>Second Part: UmbracoCMS integration</h3>

-Setting up a new Umbraco project. Implementing necessary dotnet packages to build and run the Umbraco locally (dotnet run in the cmd prompt). Created a new account and logged in UmbracoCMS. <br/>
-UmbracoCMS Setup: Created a document type for Candidate with properties for fields like candidateName and a checkbox list for Skills. <br/>
-Exposing REST API endpoints <br/>
GET https://localhost:{port}/umbraco/api/candidateapi/getcandidates <br/>
CREATE https://localhost:{port}/umbraco/api/candidateapi/createcandidates/{id} <br/>
{
    "name": "New Candidate",
    "skills": ["C#", "Umbraco", "SQL"]
}
PUT https://localhost:{port}/umbraco/api/candidateapi/updatecandidates/{id} <br/>
DELETE https://localhost:{port}/umbraco/api/candidateapi/deletecandidates/{id} <br/>


<h3>Third Part: Power BI</h3>

-Implemented Statistics controller which exposes these endpoints: <br/>
Total Candidates Count: GET statistics/total <br/>
Job Offers vs Rejections: GET statistics/decisions <br/>
Average Experience: GET statistics/averageexperience <br/>
Top Skills: GET statistics/topskills <br/>
-Created a Dashboard with charts representing the data. <br/>


<h3>First Part version 2: </h3>

-Introducing layered architecture into the project. <br/>
-Implementing Core, BusinessLayer, DataLayer as class libraries. <br/>
-Fixing all the dependencies and proper handling of the Database connection. <br/><br/>

