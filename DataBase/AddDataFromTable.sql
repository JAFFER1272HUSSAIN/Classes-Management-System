INSERT INTO Student(FirstName,LastName,Contact,Email,RegistrationNumber,Status)
SELECT First_Name,Last_Name,Contact,Email,Registration_Number,Status
FROM StagingTable
WHERE StagingTable.First_Name IS NOT NULL


