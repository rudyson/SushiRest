import '../../../../App.css'

import {IoStarSharp} from "react-icons/io5";
import {useState} from "react";

export const Rating = () => {
    const [rating, setRating] = useState(null)
    const [hover, setHover] = useState(null)
    return (
        <div className='starComponent'>
            {[...Array(5)].map((star, index) => {
                const currentRating = index + 1
                return (
                    <label>
                        <input
                            type="radio"
                            name="rating"
                            value={currentRating}
                            onClick={() => setRating(currentRating)}
                        />
                        <IoStarSharp
                            className="star"
                            color={currentRating <= (hover || rating) ? "#F6C032" : "#2E2E2E"}
                            onMouseEnter={() => setHover(currentRating)}
                            onMouseLeave={() => setHover(null)}

                        />
                    </label>
                )
            })}
        </div>
    )
}
