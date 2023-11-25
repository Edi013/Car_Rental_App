import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Car } from '../models/car';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  private apiUrl: string = environment.apiUrl;
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  constructor(private http: HttpClient) {}

  async getAllCars(): Promise<Car[]> {
    const response = this.http.get<any>(
      `${this.apiUrl}/Car/GetAll`
    );
    return await lastValueFrom(response);
  }

  async updateCar(car: Car): Promise<Car>{
    const response = this.http.put<Car>(
      `${this.apiUrl}/Car/Update`, car, this.httpOptions
    );
    return await lastValueFrom(response);
  }

  async createCar(car: Car): Promise<Car>{
    const response = this.http.post<Car>(
      `${this.apiUrl}/Car/Update`, car, this.httpOptions
    );
    return await lastValueFrom(response);
  }
    // const users: Car[] = result;
    // return users;
 

  // async getProjectManagerByProjectId(projectId: number): Promise<ProjectManager[]>
  // {
  //   let request = this.http.get<any>(`${this.apiUrl}/User/project-manager/${projectId}`);
  //   let result = await lastValueFrom(request);


  //   return projectManagers;
  // }
}
