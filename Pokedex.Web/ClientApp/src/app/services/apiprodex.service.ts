import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Filtro } from '../models/filtro';
import { Pokedex } from '../models/pokedex';
import { Respuesta } from '../models/respuesta';

const httpOption = {
  headers: new HttpHeaders({
    'Contend-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ApiprodexService {
  url: string = 'https://localhost:44384/api/PokedexApi';

  constructor(private _http: HttpClient) {
    
  }

  obtenerPokedex(filtro: Filtro): Observable<Respuesta> {
    return this._http.post<Respuesta>(this.url,filtro,httpOption);
  }

  obtenerPokedexById(id: number): Observable<Pokedex> {
    return this._http.get<Pokedex>(this.url + '/' + id)
  }


}
