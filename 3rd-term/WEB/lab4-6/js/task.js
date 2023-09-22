

// 1. Створити об’єкт «Користувач» з властивостями «Прізвище»,
// «Ім’я».

let user = {
    name: 'Dima',
    surname: 'Pestenkov'
};

// 2. Створити об’єкт «Студент», що містить властивості
// «Спеціальність», «Група» і методи: додати, змінити, видалити дані.

let student = {
    specialization: "Computer Science",
    group: "TR-14",
    addData() {
        const newSpecialization = prompt("Enter new specialization:");
        const newGroup = prompt("Enter new group:");
        this.specialization = newSpecialization;
        this.group = newGroup;
    },
    updateData() {
        this.specialization = newSpecialization = prompt("Enter new specialization:");
        this.group = newGroup = prompt("Enter new group:");
    },
    deleteData() {
        this.specialization = null;
        this.group = null;
    }
}
// 3. Реалізувати копіювання властивостей і методів об’єктів
// «Користувач» і «Студент».

// let updatedStudent = { };
// for (let key in user) {
//     updatedStudent[key] = user[key];
// }
// for (let key in student) {
//     updatedStudent[key] = student[key];
// }

let updatedStudent = Object.assign({}, user, student);

console.log(updatedStudent)

// 4. Додати в прототип об’єкту «Студент» метод «Показати дані»

function Student(name, surname, specialization, group){
    this.name = name;;
    this.surname = surname;
    this.specialization = specialization;
    this.group = group;

    this.addData = function() {
        const newSpecialization = prompt("Enter new specialization:");
        const newGroup = prompt("Enter new group:");
        this.specialization = newSpecialization;
        this.group = newGroup;
    };
    this.updateData = function() {
        this.specialization =  prompt("Enter new specialization:");
        this.group = prompt("Enter new group:");
    };
    this.deleteData = function() {
        this.specialization = null;
        this.group = null;
    }
}

Student.prototype.showData = function () {
    console.log(`Student fullname: ${this.name} ${this.surname}, group: ${this.group}, specialization: ${this.specialization}`);
}

let dima = new Student("Dima", "Pestenkov", "CS", "TR-14");
dima.showData();
// dima.updateData();
// dima.showData();

// 5. Створити об’єкт «Успішність», що наслідує властивості і методи
// об’єкту «Студент» і має додаткові властивості «Тест», «Спроба», «Бали»
// і метод «Розрахунок середнього балу» (за декілька спроб).
// Перевизначити в об’єкті «Успішність» метод «Показати дані».

function Success(name, surname, specialization, group){
    Student.call(this, name, surname, specialization, group);
    this.marks = []
    this.count = 0;
    this.addResult = function(mark){
        this.marks.push(mark);
        this.count++;
    }
    
    this.getAvgMark = function() {
        let avg = 0;
        for(let mark of this.marks){
            avg += mark;
        }
        return avg / this.count;
    }
    this.showData = function() {
        console.log(`Student ${this.name} ${this.surname} did ${this.count} tests with average mark ${this.getAvgMark() || 0} `);
    }
}
let richard = new Success("Richard", "Brown", "CS", "TR-14");
richard.addResult(7.3);
richard.addResult(8.1);
richard.addResult(9.9);
richard.addResult(4.6);
richard.showData();



// 6. Реалізувати класи «Студент» і «Успішність» з такими же
// методами і властивостями як і попередні об’єкти. «Успішність» наслідує
// методи та властивості від «Студент». При реалізації використовувати
// геттери і сеттери, наприклад, для перевірки даних чи виведення в різних
// виглядах інформацію.

class StudentClass {
    constructor(name, surname, specialization, group) {
        this._name = name;
        this._surname = surname;
        this._specialization = specialization;
        this._group = group;
    }
    get name() {
        return this._name
    }
    set name(value) {
        if(value.length < 3) {
            console.log("Invalid name, too short");
                return
        }
        this._name = value;
    }
    get surname() {
        return this._surname
    }
    set surname(value) {
        if(value.length < 3) {
            console.log("Invalid surname, too short");
                return
        }
        this.surname = value;  
    }

    get fullName() {
        return `${this._name} ${this._surname}`;
    }
    set fullName(value) {
        [this._name, this._surname] = value.split(" ");
    }

    get specialization() {
        return this._specialization
    }
    set specialization(value) {
        this._specialization = value; 
    }
    get group() {
        return this._group
    }
    set group(value) {
        this._group = value; 
    }
    addData = function () {
        const newSpecialization = prompt("Enter new specialization:");
        const newGroup = prompt("Enter new group:");
        this._specialization = newSpecialization;
        this._group = newGroup;
    };
    updateData = function () {
        this._specialization = prompt("Enter new specialization:");
        this._group =  prompt("Enter new group:");
    };
    deleteData = function () {
        this._specialization = null;
        this._group = null;
    };

    showData() {
        console.log(`Student fullname: ${this.fullName}, group: ${this._group}, specialization: ${this._specialization}`);
    }
}

class SuccessClass extends StudentClass{
    constructor(student){
        super(student.name, student.surname, student.specialization, student.group)
        this._marks = [];
        this._count = 0;
    }

    addResult(mark){
        this._marks.push(mark);
        this._count++;
    }
    get count() {
        return this._count;
    }
    set count(value) {
        this._count = value;
    }
    get marks() {
        return this._marks;
    }
    set marks(value) {
        this._marks = value;
    }
    getAvgMark() {
        let avg = 0;
        for(let mark of this._marks){
            avg += mark;
        }
        return avg / this._count;
    }
    showData() {
        console.log(`Student ${this.fullName} did ${this._count} tests with average mark ${this.getAvgMark() || 0} `);
    }
}

let roberto = new StudentClass("Roberto", "Johnson", "CS", "TR-14");
let robertoSuccess = new SuccessClass(roberto);
robertoSuccess.addResult(3.3);
robertoSuccess.addResult(2.1);
robertoSuccess.addResult(9.1);
robertoSuccess.addResult(6.5);
robertoSuccess.showData();
