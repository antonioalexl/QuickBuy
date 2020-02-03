import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http"
import { Observable } from "rxjs";
import { Usuario } from "../../modelo/usuario";

@Injectable({

  providedIn: "root"

})
export class UsuarioServico {

  private baseURL: string;
  private _usuario: Usuario;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;

  }

  set usuario(usuario: Usuario) {
    sessionStorage.setItem("usuario-autenticado", JSON.stringify(usuario));
    this._usuario = usuario;
  }

  get usuario(): Usuario {

    let usuario_json = sessionStorage.getItem("usuario-autenticado");
    return this._usuario = JSON.parse(usuario_json);
  }

  public usuario_autenticado(): boolean {
    return this._usuario != null && this._usuario.email != "" && this.usuario.senha != "";

  }
  public limpar_sessao() {
    sessionStorage.setItem("usuario-autenticado", "");
    this._usuario = null;

  }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  public verificarUsuario(usuario: Usuario): Observable<Usuario> {

    
    var body = {
      email: usuario.email,
      senha: usuario.senha

    }
    return this.http.post<Usuario>(this.baseURL + "api/usuario", body, { headers: this.headers });
  }


  public cadastrarUsuario(usuario: Usuario): Observable<Usuario> {
    
    return this.http.post<Usuario>(this.baseURL + "api/usuario", JSON.stringify(usuario), { headers: this.headers });

  }


}



