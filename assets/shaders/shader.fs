#version 330 core

out vec4 FragColor;
in vec3 oPos;

uniform float time;
uniform float ypos;
uniform float xpos;
uniform float zoom;

vec3 palette[16] = vec3[16](
    vec3(0.0f/255.0f, 0.0f/255.0f, 0.0f/255.0f),
    vec3(25.0f/255.0f, 7.0f/255.0f, 26.0f/255.0f),
    vec3(9.0f/255.0f, 1.0f/255.0f, 47.0f/255.0f),
    vec3(4.0f/255.0f, 4.0f/255.0f, 73.0f/255.0f),
    vec3(0.0f/255.0f, 7.0f/255.0f, 100.0f/255.0f),
    vec3(12.0f/255.0f, 44.0f/255.0f, 138.0f/255.0f),
    vec3(24.0f/255.0f, 82.0f/255.0f, 177.0f/255.0f),
    vec3(57.0f/255.0f, 125.0f/255.0f, 209.0f/255.0f),
    vec3(134.0f/255.0f, 181.0f/255.0f, 229.0f/255.0f),
    vec3(211.0f/255.0f, 236.0f/255.0f, 248.0f/255.0f),
    vec3(241.0f/255.0f, 233.0f/255.0f, 191.0f/255.0f),
    vec3(248.0f/255.0f, 201.0f/255.0f, 95.0f/255.0f),
    vec3(255.0f/255.0f, 170.0f/255.0f, 0.0f/255.0f),
    vec3(204.0f/255.0f, 128.0f/255.0f, 0.0f/255.0f),
    vec3(153.0f/255.0f, 87.0f/255.0f, 0.0f/255.0f),
    vec3(106.0f/255.0f, 52.0f/255.0f, 3.0f/255.0f)
);

void main()
{
  #define square(a, b) vec2((pow(a, 2) - pow(b, 2)), (2 * a * b))
  #define length(a) sqrt(pow(a.x, 2) + pow(a.y, 2))

  vec2 z = vec2((oPos.x * 2.0f) * zoom + xpos, (oPos.y * 2.0f) * zoom + ypos);
  vec2 zInitial = z;
  
  int i = 0;
  while(i<100 && length(z) <= 2.0f)
  {
     z = vec2(square(z.x, z.y).x + zInitial.x + (time * zoom), square(z.x, z.y).y + zInitial.y + (time * zoom));
     i++;
  }

   (i == 100) ? FragColor = vec4(0.0f) : FragColor = vec4(palette[i%16], 1.0f);
}
