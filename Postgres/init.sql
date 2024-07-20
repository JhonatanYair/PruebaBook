CREATE TABLE authors (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL
);

CREATE TABLE books (
    id SERIAL PRIMARY KEY,
    title VARCHAR(200) NOT NULL,
    author_id INTEGER REFERENCES authors(id)
);

INSERT INTO authors (name) VALUES 
('Gabriel García Márquez'), 
('Jane Austen'), 
('George Orwell'),
('J.K. Rowling'),
('J.R.R. Tolkien'),
('Mark Twain'),
('Ernest Hemingway'),
('F. Scott Fitzgerald'),
('Agatha Christie'),
('Leo Tolstoy');

INSERT INTO books (title, author_id) VALUES 
-- Gabriel García Márquez
('Cien años de soledad', 1), 
('El amor en los tiempos del cólera', 1),

-- Jane Austen
('Orgullo y prejuicio', 2),
('Sentido y sensibilidad', 2),
('Emma', 2),

-- George Orwell
('1984', 3),
('Rebelión en la granja', 3),

-- J.K. Rowling
('Harry Potter y la piedra filosofal', 4),
('Harry Potter y la cámara secreta', 4),
('Harry Potter y el prisionero de Azkaban', 4),

-- J.R.R. Tolkien
('El hobbit', 5),
('La comunidad del anillo', 5),
('Las dos torres', 5),
('El retorno del rey', 5),

-- Mark Twain
('Las aventuras de Tom Sawyer', 6),
('Las aventuras de Huckleberry Finn', 6),

-- Ernest Hemingway
('El viejo y el mar', 7),
('Por quién doblan las campanas', 7),

-- F. Scott Fitzgerald
('El gran Gatsby', 8),
('Suave es la noche', 8),

-- Agatha Christie
('Asesinato en el Orient Express', 9),
('Diez negritos', 9),

-- Leo Tolstoy
('Guerra y paz', 10),
('Anna Karenina', 10);

