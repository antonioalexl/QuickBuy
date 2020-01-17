import { Injectable } from "@angular/core";
import { Router, CanActivate, ActivatedRouterSnapshot, RouterStateSnapshot } from "@angular/router";

export class GuardaRotas implements CanActivate {

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {

    throw new Error("Method not implemented");
  }
}
