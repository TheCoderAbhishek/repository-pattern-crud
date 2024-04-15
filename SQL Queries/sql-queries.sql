-- Query to create a table for this project.
CREATE TABLE public.CricketTeams (
    TeamId SERIAL PRIMARY KEY,
    TeamName VARCHAR(100) NOT NULL,
    LogoImage VARCHAR(255) NOT NULL,
    Captain VARCHAR(100) NOT NULL,
    Coach VARCHAR(100) NOT NULL
);

-- Query to fetch data from table
SELECT * FROM public."CricketTeams";

