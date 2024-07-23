shader_type spatial;

render_mode unshaded, cull_disabled; //Ignores lighting, makes sure both sides are white

uniform bool active = false; //Uniform is basically keyword for public, we can modify it outside of the file
uniform vec4 flash_color: source_color = vec4(1.0, 1.0 ,1.0 ,1.0); //A Vector in Shader's are like an array. this Vec4 stores 4 numbers, this one will store r,g,b,a for the color
//In this case 1.0 represents 100%, or 255 for rgb or 100% for alpha

uniform sampler2D tex : source_color; 

void fragment() //Gets called for every pixel in our image
{
	vec4 color = texture(tex, UV);
	
	ALPHA = color.a;
	
	if(active == true)
	{
		color = flash_color;
	}
	
	ALBEDO = vec3(color.r, color.g, color.b);
	
}
