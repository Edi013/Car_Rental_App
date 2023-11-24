import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Car } from '../models/car';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  private apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  async getAllCars(): Promise<Car[]> {
    const response = this.http.get<any>(
      `${this.apiUrl}/Car/GetAll`
    );
    const result = await lastValueFrom(response);

    const users: Car[] = result;
    return users;
  }

  // async getProjectManagerByProjectId(projectId: number): Promise<ProjectManager[]>
  // {
  //   let request = this.http.get<any>(`${this.apiUrl}/User/project-manager/${projectId}`);
  //   let result = await lastValueFrom(request);


  //   return projectManagers;
  // }
}
