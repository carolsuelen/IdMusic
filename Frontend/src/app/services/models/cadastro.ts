export class CadastroInput {
    constructor (
       public name: string,
       public email: string,
       public password: string,
       public genreId: number,
       public birthday: string,
       public photo:string,
       public photoCapa: string,
       public biografy: string,
       public band: string
    ){}
}
  