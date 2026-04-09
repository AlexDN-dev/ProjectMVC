USE ProjectMVC;
GO

-- Roles
INSERT INTO Roles (RoleName)
VALUES
    ('Admin'),
    ('Manager'),
    ('User');
GO

-- Users
INSERT INTO Users (Firstname, Lastname, Email, PasswordHash)
VALUES
    ('Alexandre', 'Deneve', 'alexandre.deneve@example.com', '$2a$11$FakeHashAdmin'),
    ('Mirko', 'Aiesi', 'mirko.aiesi@example.com', '$2a$11$FakeHashUser4'),
    ('Marie', 'Dupont', 'marie.dupont@example.com', '$2a$11$FakeHashUser1'),
    ('Lucas', 'Martin', 'lucas.martin@example.com', '$2a$11$FakeHashUser2'),
    ('Emma', 'Bernard', 'emma.bernard@example.com', '$2a$11$FakeHashUser3'),
    ('Thomas', 'Petit', 'thomas.petit@example.com', '$2a$11$FakeHashUser4');
GO

-- UserRoles
INSERT INTO UserRoles (UserId, RoleId)
VALUES
    (1, 1), -- Alexandre = Admin
    (2, 3), -- Marie = User
    (3, 3), -- Lucas = User
    (4, 2), -- Emma = Manager
    (5, 3); -- Thomas = User
GO