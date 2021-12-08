import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TodoItem } from '../models/todo-item.model';

@Injectable({
  providedIn: 'root'
})

export class TodoAppService {
  readonly baseURL = "http://localhost:5000/api/ToDoItem";
  list: TodoItem[]=[];

  constructor(private http: HttpClient) { }

  create(todoData: TodoItem) {
    return this.http.post(this.baseURL, todoData, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  update(todoData: TodoItem) {
    return this.http.put(this.baseURL, todoData, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  delete(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  refreshList() {
    this.http.get(this.baseURL)
    .toPromise()
    .then(res => {
      this.list = res as TodoItem[]
    });
  }
}
