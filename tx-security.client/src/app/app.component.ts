import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface SecurityToken {
  accessToken: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public securityToken: SecurityToken | undefined;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getTokens();
  }

  getTokens() {
    this.http.get<SecurityToken>('/txsecuritytoken').subscribe(
      (result) => {
        this.securityToken = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'tx-security.client';
}
