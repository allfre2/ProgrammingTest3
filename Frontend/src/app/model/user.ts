export interface User {
    fullName: string;
    firstName: string;
    lastName: string;
    role: Role;
    createdOn: Date;
    imgURL?: string;
    email: string;
}

export enum Role {
    Admin,
    Seller,
    User
}