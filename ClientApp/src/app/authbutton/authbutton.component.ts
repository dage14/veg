
import { Component, OnInit, Inject } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { DOCUMENT } from '@angular/common';


@Component({
  selector: 'app-authbutton',
  template: `
  <ng-container *ngIf="auth.isAuthenticated$ | async; else loggedOut">
    <button (click)="auth.logout({ returnTo: document.location.origin })">
      Log out
    </button>
  </ng-container>

  <ng-template #loggedOut>
    <button (click)="auth.loginWithRedirect()">Log in</button>
  </ng-template>
`,
  //templateUrl: './authbutton.component.html',
  styleUrls: ['./authbutton.component.css']
})
export class AuthbuttonComponent implements OnInit {

  constructor(@Inject(DOCUMENT) public document: Document, public auth: AuthService) {
    //console.log('authResult', auth.user$) ;
    auth.user$.subscribe( x => console.log(x.email ));
  }

  ngOnInit() {
  }

}
