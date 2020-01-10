import { Component } from '@angular/core';
import { Usuario } from '../../modelo/usuario';


@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent {

  public usuario;
  public usuarioAutenticado: boolean;


  constructor() { this.usuario = new Usuario();}


  public email = "antonio.alex@hotmail.com"
  public senha = ""

  entrar(): void {

    


    alert(this.email);

  }
  on_Keypress() {
    alert('foi digitado no campo de email');
  }
}
