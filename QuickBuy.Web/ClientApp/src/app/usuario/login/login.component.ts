import { Component, OnInit } from '@angular/core';
import { Usuario } from '../../modelo/usuario';
import { Router, ActivatedRoute } from "@angular/router";


@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {

  public usuario;
  public usuarioAutenticado: boolean;
  public returnUrl: string;

  constructor(private router: Router, private activatedRouter: ActivatedRoute) {
    this.usuario = new Usuario();
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
  }


  public email = "antonio.alex@hotmail.com"
  public senha = ""

  entrar(): void {

    if (this.usuario.email == "antonio.alex@hotmail.com" && this.usuario.senha == "123456") {
      sessionStorage.setItem("usuario-autenticado", "1");
      this.router.navigate([this.returnUrl]);
    }


    alert(this.email);

  }
  on_Keypress() {
    alert('foi digitado no campo de email');
  }
}
