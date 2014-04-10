class Student {
    static int nrOfStudents;

    String name = "DEFAULT NAME";
    int id;

    static {
        nrOfStudents = 0;
    }

    public Student(String n) {
        name = n;
    }
}

