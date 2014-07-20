require ['chance', 'underscore', 'student', 'animal', 'book', 'person'],
 (Chance, _, Student, Animal, Book, Person) ->

  NUMBER_OF_LEGS = [2, 4, 6, 8, 100]
  NAME_OF_SPECIES = ['Lion', 'Horse', 'Cat', 'Dog', 'Bat', 'Centipede']
  AUTHORS_NAMES = ['John Peterson', 'George Dickens', 'Nostradamus']

  chance = new Chance()

  #Generate People
  makePerson = () ->
    person = new Person chance.first(), chance.last()

  people = (makePerson() for person in [1..100])

  #Generate Students
  generateMarks = () ->
    (chance.integer({min: 2, max: 6}) for mark in [1..5])

  makeStudent = () ->
   student = new Student chance.first(), chance.last(), chance.age(), generateMarks()

  students = (makeStudent() for student in [1..20])

  #Generate Books
  makeBook = () ->
    indexOfName = chance.integer({min: 0, max: AUTHORS_NAMES.length - 1})
    book = new Book AUTHORS_NAMES[indexOfName], chance.sentence({words: 2})

  books = (makeBook() for book in [1..20])

  #Generate Animals
  makeAnimal = () ->
    indexOfSpecies = chance.integer({min: 0, max: NAME_OF_SPECIES.length - 1})
    indexOfLegs = chance.integer({min: 0, max: NUMBER_OF_LEGS.length - 1})
    animal = new Animal NAME_OF_SPECIES[indexOfSpecies], NUMBER_OF_LEGS[indexOfLegs]

  animals = (makeAnimal() for animal in [1..20])

  #Task One
  filteredAndSortedByLastName = _.chain students
                                 .filter (student)-> student.firstName < student.lastName
                                 .sortBy (student) -> student.firstName + student.lastName
                                 .reverse()
                                 .value()

  console.log "Filtered by firstName compared to lastName and then sorted by fullname descending."
  console.log filteredAndSortedByLastName

  #Task Two
  filteredByAge = _.chain students
                   .filter (student) -> 18 <= student.age <= 24
                   .map (student) -> {firstName: student.firstName, lastName: student.lastName}
                   .value()

  console.log "Filtered by age and print object with first and last name."
  console.log filteredByAge

  #Task Three
  studentWithHighestMarks = _.chain students
                             .sortBy (student) -> student.marks.reduce (a, b) -> a + b
                             .last()
                             .value()

  console.log "Student with highest marks is #{studentWithHighestMarks}"

  #Task Four
  # animalsGroupedBySpeciesAndSortedByLegs = _.chain animals
  #                                           .groupBy 'specie'
  #                                           .map (group) -> _.sortBy group, (animal) -> animal.legs
  #                                           .value()
  animalsGroupedBySpeciesAndSortedByLegs = _.chain animals
                                          .sortBy 'legs'
                                          .groupBy 'specie'
                                          .value()

  console.log "Prints animals grouped by species and sorted by number of legs."
  console.log animalsGroupedBySpeciesAndSortedByLegs

  #Task Five
  totalNumberOfLegs = _.reduce animals, ((acc, animal) -> acc + animal.legs), 0

  console.log "Total number of legs are #{totalNumberOfLegs}"

  #Task Six
  mostPopularAuthor = _.chain books
                       .groupBy 'author'
                       .max (group) -> group.length
                       .first()
                       .value()
                       .author

  console.log "The most popular author is #{mostPopularAuthor}"

  #Task Seven
  groupAndSortPeopleBy = (property) ->
    biggestGroup = _.chain people
                    .groupBy property
                    .max (group) -> group.length
                    .value()

    count = biggestGroup.length
    mostCommonProperty = (_.last biggestGroup)[property]
    {count: count, mostCommonProperty : mostCommonProperty }

  byFirstName = groupAndSortPeopleBy 'firstName'
  byLastName = groupAndSortPeopleBy 'lastName'

  console.log "The most popular first name is #{byFirstName.mostCommonProperty}
               - count: #{byFirstName.count}"
  console.log "The most popular last name is #{byLastName.mostCommonProperty}
               - count: #{byLastName.count}"
