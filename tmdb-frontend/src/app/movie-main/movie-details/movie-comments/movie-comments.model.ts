export class MovieComment {
    Id:number
    MovieId:number
    Value:string
    CreatedBy:string
    CreatedOn:Date
    UpdatedBy:string
    UpdatedOn:Date
    
    /**
     * Constructor
     *
     * @param comment
     */
    constructor(comment) {
        {
            this.Id = comment.Id || 0;
            this.MovieId = comment.MovieId || 0;
            this.Value = comment.Value || '';
            this.CreatedBy = comment.CreatedBy || '';
            this.CreatedOn = comment.CreatedOn || new Date();
            this.UpdatedBy = comment.UpdatedBy || '';
            this.UpdatedOn = comment.UpdatedOn || new Date();
        }
    }
}
