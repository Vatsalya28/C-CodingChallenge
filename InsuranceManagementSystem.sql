
CREATE TABLE Users (
user_id INT PRIMARY KEY IDENTITY(1,1),
username VARCHAR(50) NOT NULL,
password VARCHAR(50) NOT NULL,
role VARCHAR(10) CHECK (role IN ('admin', 'agent', 'client')) NOT NULL
)


CREATE TABLE Policies (
policy_id INT PRIMARY KEY IDENTITY(1,1),
policy_number VARCHAR(20) NOT NULL,
policy_type VARCHAR(50) NOT NULL,
coverage_amount DECIMAL(10, 2) NOT NULL,
premium_amount DECIMAL(8, 2) NOT NULL,
start_date DATE NOT NULL,
end_date DATE NOT NULL
)
select * from Policies

CREATE TABLE Clients (
client_id INT PRIMARY KEY IDENTITY(1,1),
client_name VARCHAR(100) NOT NULL,
contact_info VARCHAR(255),
policy_id INT,
FOREIGN KEY (policy_id) REFERENCES Policies(policy_id)
)


CREATE TABLE Claims (
claim_id INT PRIMARY KEY IDENTITY(1,1),
claim_number VARCHAR(20) NOT NULL,
date_filed DATE NOT NULL,
claim_amount DECIMAL(10, 2) NOT NULL,
status VARCHAR(10) CHECK (status IN ('pending', 'approved', 'denied')) NOT NULL,
policy_id INT,
client_id INT,
FOREIGN KEY (policy_id) REFERENCES Policies(policy_id),
FOREIGN KEY (client_id) REFERENCES Clients(client_id)
)


CREATE TABLE Payments (
payment_id INT PRIMARY KEY IDENTITY(1,1),
payment_date DATE NOT NULL,
payment_amount DECIMAL(8, 2) NOT NULL,
client_id INT,
FOREIGN KEY (client_id) REFERENCES Clients(client_id)
)


----Data insertion

INSERT INTO Users (username, password, role) VALUES
('ronaldo', 'password123', 'admin'),
('messi', 'pass456', 'agent'),
('neymar', 'pass', 'client'),
('mbappe', 'pass123', 'admin'),
('lewandowski', 'football123', 'agent')

INSERT INTO Policies (policy_number, policy_type, coverage_amount, premium_amount, start_date, end_date) VALUES
('P001', 'Life Insurance', 50000.00, 100.00, '2023-01-01', '2023-12-31'),
('P002', 'Auto Insurance', 30000.00, 50.00, '2023-02-01', '2023-12-31'),
('P003', 'Health Insurance', 100000.00, 120.00, '2023-03-01', '2023-12-31'),
('P004', 'Home Insurance', 80000.00, 80.00, '2023-04-01', '2023-12-31'),
('P005', 'Travel Insurance', 20000.00, 30.00, '2023-05-01', '2023-12-31')

INSERT INTO Clients (client_name, contact_info, policy_id) VALUES
('Ramos', 'ramos@example.com', 1),
('Kane', 'kane@example.com', 2),
('Salah', 'salah@example.com', 3),
('De Bruyne', 'debruyne@example.com', 4),
('Lukaku', 'lukaku@example.com', 5)

INSERT INTO Claims (claim_number, date_filed, claim_amount, status, policy_id, client_id) VALUES
('CLM001', '2023-02-15', 5000.00, 'pending', 1, 1),
('CLM002', '2023-03-20', 8000.00, 'approved', 2, 2),
('CLM003', '2023-04-25', 12000.00, 'denied', 3, 3),
('CLM004', '2023-05-10', 6000.00, 'pending', 4, 4),
('CLM005', '2023-06-05', 3000.00, 'approved', 5, 5)

INSERT INTO Payments (payment_date, payment_amount, client_id) VALUES
('2023-01-05', 50.00, 1),
('2023-02-10', 30.00, 2),
('2023-03-15', 80.00, 3),
('2023-04-20', 40.00, 4),
('2023-05-25', 25.00, 5)

select * from claims
select * from Clients
select * from Payments
select * from Policies
select * from Users