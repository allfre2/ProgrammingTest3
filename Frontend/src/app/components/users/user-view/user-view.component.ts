import { Component } from '@angular/core';
import { Role, User } from 'src/app/model/user';

@Component({
  selector: 'user-view',
  templateUrl: './user-view.component.html',
  styleUrls: ['./user-view.component.scss']
})
export class UserViewComponent {
  sampleUsers: User[] = [];

  constructor() {}

  ngOnInit(): void {
    let date = new Date();
    date.setDate(date.getDate() - 10);
    this.sampleUsers = [
      {
        firstName: 'Alfredo',
        lastName: 'Luzón',
        fullName: 'Alfredo Luzón',
        role: Role.Admin,
        createdOn: date,
        imgURL: 'https://static.vecteezy.com/system/resources/previews/000/439/863/original/vector-users-icon.jpg',
        email: 'aluzon@company.com'
      },
      {
        firstName: 'Aymara',
        lastName: 'Perez',
        fullName: 'Aymara Perez',
        role: Role.Seller,
        createdOn: date,
        imgURL: 'https://cdn.pixabay.com/photo/2014/04/03/10/32/user-310807_640.png',
        email: 'aperez@company.com'
      },
      {
        firstName: 'Alberto',
        lastName: 'Medina',
        fullName: 'Alberto Medina',
        role: Role.User,
        createdOn: new Date(),
        imgURL: 'https://images.unsplash.com/photo-1633332755192-727a05c4013d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8dXNlcnxlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80',
        email: 'amedina@company.com'
      }
    ];
  }
}
