import { Component, OnInit } from '@angular/core';
import { TodoItem } from '../models/todo-item.model';
import { TodoAppService } from '../services/todo-app.service';

@Component({
  selector: 'app-todo-items',
  templateUrl: './todo-items.component.html',
  styles: [
  ]
})

export class TodoItemsComponent implements OnInit {
  newDescription: string;

  constructor(public service: TodoAppService) {
    this.newDescription = "";
  }

  ngOnInit(): void {
    this.service.refreshList();
  }

  onCreate(description: string): void {
    var newItem = new TodoItem();
    newItem.description = description;
    this.service.create(newItem)
    .subscribe( res => {
      this.service.refreshList();
    },
    err => {
      console.log(err);
    });
  }

  onCompleteToggle(item: TodoItem): void {
    item.isCompleted = !item.isCompleted;
    this.service.update(item)
    .subscribe( res => {
      this.service.refreshList();
    },
    err => {
      console.log(err);
    });
  }

  onDelete(item: TodoItem): void {
    if (item.isCompleted || confirm("Are you sure you want to delete this uncompleted item?")) {
      this.service.delete(item.id)
      .subscribe( res => {
        this.service.refreshList();
      },
      err => {
        console.log(err);
      })
    }
  }
}
