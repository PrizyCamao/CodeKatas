
export interface InfoData {
    title: string,
    timeframes: {
        daily: {
            current: number,
            previous: number,
        },
        weekly: {
            current: number,
            previous: number,
        },
        monthly: {
            current: number,
            previous: number,
        },
    }
    style: {
        color: string,
        img: string,
    }
}