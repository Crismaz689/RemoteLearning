export interface ICreateAccount {
    firstName: string,
    surname: string,
    pesel: string,
    birthdayDate: Date,
    email: string,
    roleId: number // 1 = Admin, 2 = User, 3 = Tutor
}