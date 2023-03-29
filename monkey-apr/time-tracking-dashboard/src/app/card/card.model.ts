export interface Card {
  title: string;
  timeframes: {
    daily: CardDetail,
    weekly: CardDetail,
    monthly: CardDetail
  }
  background?: string;
}

export interface CardDetail {
  current: number;
  previous: number;
}
