### Main idea
The main idea of the project is the creation of a school resource management system (Like Shkolo), that is easy to maintain, scalable, accessible and offers an all in one integrated exeperience for managing students and their activities.

## Core features:
- Online grading system with a web portal so that the students can see their grades at any time and teachers can grade them.
- Online absence management system.
- Portal for schools/universities to register and manage their students.
- Support for multiple institutions with their own administration and students.
- An online Index where students can browse between educational institutions using the system and can get more info about them.
- A ranking system that allows the students to see how they compete in certain spheres with their peers in and outside their schools.
-  A system to analyze the strengths and weaknesses of a student in order to rank them based on their performance
- A system to recommend the student materials and courses based on their performance in order to improve on their weaknesses.

### Architecture: 
The school management system uses the monolith architecture but can be expanded to a microserivce architecture running on docker swarm, kubernetes etc.

Database: Mysql server hosted on a docker container. 
ORM: Entity Framework
Backend: Asp.net Core 6 web api
Frontend: SPA using Vue 3 with vue router.
Object storage: MiniIO container hosted from a docker container
Type of Authentication: JWT Token

### Roadmap

- [x] User authentication
- [x] User registration
- [x] Grades
- [x] Adding and deleting users
- [x] Adding and deleting courses and majors
- [ ] GPI for every student
- [ ] Support for multiple schools and differentiation between their user
- [ ] Profile customization
- [x] Light and dark mode
- [ ] Absence support
- [ ] Term and yearly grade support
- [ ] Weekly program support
- [ ] Personalized study resource recommendation service for each user
