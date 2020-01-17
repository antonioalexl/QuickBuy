import { Component, OnInit } from '@angular/core';
import { Usuario } from '../../modelo/usuario';
import { Router, ActivatedRoute } from "@angular/router";
import { UsuarioServico } from '../../servicos/usuario/usuario.servico';


@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {


  public usuario;
  public usuarioAutenticado: boolean;
  public returnUrl: string;
  public mensagem: string;
  public ativar_spinner: boolean;

  constructor(private router: Router, private activatedRouter: ActivatedRoute, private usuarioServico: UsuarioServico) {


  }

  ngOnInit(): void {
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
    this.usuario = new Usuario();
  }



  public email = "antonio.alex@hotmail.com"
  public senha = ""

  entrar(): void {
    this.ativar_spinner = true;

    this.usuarioServico.verificarUsuario(this.usuario).subscribe(
      usuario_json => {

        this.usuarioServico.usuario = usuario_json;

        if (this.returnUrl == null) {
          this.router.navigate(['/']);
        }
        else {
          this.router.navigate([this.returnUrl]);
        }

        this.ativar_spinner = false;

      },
      err => {

        console.log(err.error);
        this.mensagem = err.error;
        this.ativar_spinner = false;
      }
     
    );

    //if (this.usuario.email == "antonio.alex@hotmail.com" && this.usuario.senha == "123456") {
    //  sessionStorage.setItem("usuario-autenticado", "1");
    //  this.router.navigate([this.returnUrl]);
    //}


    //alert(this.email);

  }
  on_Keypress() {
    alert('foi digitado no campo de email');
  }
}
