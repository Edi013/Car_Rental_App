import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  // async getUsersWithRoles(): Promise<User[]> {
  //   const response = this.http.get<any>(
  //     `${this.apiUrl}/User/with-roles`
  //   );
  //   const result = await lastValueFrom(response);
  //   const users: User[] = result.users;
  //   return users;
  // }

  // async getProjectManagerByProjectId(projectId: number): Promise<ProjectManager[]>
  // {
  //   let request = this.http.get<any>(`${this.apiUrl}/User/project-manager/${projectId}`);
  //   let result = await lastValueFrom(request);


  //   return projectManagers;
  // }
}
